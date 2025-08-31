const whiteList = [
	"http://localhost:4200",
	"https://ngweatherapp1.netlify.app/",
];
const corsOptions = {
	origin: function (origin, callback) {
		if (whiteList.indexOf(origin) !== -1 || !origin) {
			callback(null, true);
		} else {
			callback(new Error("Not allowed by CORS"));
		}
	},
};

exports.corsOptions = corsOptions;
