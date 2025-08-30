const express = require("express");
const cors = require("cors");
const dotenv = require("dotenv");

const { corsOptions } = require("./corsOptions");
const { appLimiter } = require("./rateLimitConfig");

dotenv.config();

const app = express();

app.use(cors(corsOptions));
app.use(express.json());
app.use(appLimiter);

const api = express.Router();

app.use("/api", api);

api.get("/weather", async (req, res) => {
	try {
		const response = await fetch(
			`${process.env.API_URL}?key=${process.env.API_KEY}&q=${req.query.city}&days=1&aqi=no&alerts=no`
		);
		const data = await response.json();
		res.json(data);
	} catch (error) {
		res.status(500).json({ error: "Failed to fetch weather data" });
	}
});

app.listen(process.env.PORT || 3000, () => {
	console.log(`Server is running at http://localhost:${process.env.PORT}`);
	console.log("Press CTRL+C to stop the server");
});
