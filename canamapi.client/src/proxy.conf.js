const PROXY_CONFIG = [
  {
    context: ["/weatherforecast", "/station", "/zone"],
    target: "https://localhost:7007",
    secure: false,
  },
];

module.exports = PROXY_CONFIG;
