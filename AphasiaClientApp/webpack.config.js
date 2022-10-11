const webpack = require("webpack")
const path = require("path")


module.exports = {
    mode: "development" ,
    entry: {
        foo: './index.js',
        bar: './index2.js'
    },

    output: {
        path: path.join(__dirname, 'wwwroot'),
        filename: '[name].bundle.js', // Hacky way to force webpack   to have multiple output folders vs multiple files per one path
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