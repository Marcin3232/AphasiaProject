const webpack = require("webpack")
const path = require("path")


module.exports = {
    mode: "development" ,
    entry: [
    "./index.js"
    ],
    output: {
        path: path.resolve(__dirname, "wwwroot"),
        filename: "BlazorApp.js"
    },

    module: {
        rules: [
            //ts
            {
                test: /\.tsx?$/,
                exclude: /node_modules/,
                use: "ts-loader"
            }
        ]
    }
}