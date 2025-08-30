const limiter = require("express-rate-limit");

const appLimiter = limiter.rateLimit({
	windowMs: 15 * 60 * 1000, // 15 Minutes
	max: 100, // max requests per IP
	message: "Too many requests from this IP, please try again later",
});

module.exports = { appLimiter };
