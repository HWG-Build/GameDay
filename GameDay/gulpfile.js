/// <binding BeforeBuild='styles, clean, bundle' ProjectOpened='watch' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

// <binding Clean='clean' />
//"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglifyjs"),
    util = require("gulp-util"),
    sass = require("gulp-sass"),
    ts = require("gulp-typescript"),
    bundle = require("gulp-bundle-assets");

var paths = {
    webroot: "./"
};


//assign paths to js and css files into a variable
paths.js = paths.webroot + "Scripts/js/*.js";
paths.minJs = paths.webroot + "Scripts/js/*.min.js";
paths.css = paths.webroot + "Content/*.css";
paths.minCss = paths.webroot + "Content/*.min.css";
paths.concatJsDest = paths.webroot + "Public/*.js";
paths.concatCssDest = paths.webroot + "Public/*.css";
paths.concatJsMapDest = paths.webroot + "Scripts/js/site.min.js.map";
paths.sass = paths.webroot + "Content/*.scss";
paths.typescript = paths.webroot + "Scripts/js/site.ts";
paths.typescriptChatRoom = paths.webroot + "Scripts/js/chatroom.ts";


//grabs all minified js files in location given and deletes them
gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

//grabs all minified css files in given location and deletes them
gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

//grabs all js.map files in given location and deletes them
gulp.task("clean:jsmap", function (cb) {
    rimraf(paths.concatJsMapDest, cb);
});

//fires all task in the [] when "clean" is called
gulp.task("clean", ["clean:js", "clean:css", "clean:jsmap"]);


//grabs all js files in location given and minifies them
gulp.task("min:js", function () {
    return gulp.src(paths.js)
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify({
            outSourceMap: true
}).on('error', util.log))
        .pipe(gulp.dest("./"));
});

//grabs all css files in location given and minifies them
gulp.task("min:css", function () {
    return gulp.src(paths.css)
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin().on('error', util.log))
        .pipe(gulp.dest("./"));
});

//fires all task in [] when "min" is called
gulp.task("min", ["min:js", "min:css"]);


//compiles sass files into css in the given location
gulp.task('styles', function () {
    gulp.src(paths.sass)
        .pipe(sass().on('error', util.log))
        .pipe(gulp.dest('./Content/'));
});

//Watch task that fires whenever what is being watched is changed
gulp.task('watch', function () {
    gulp.watch(paths.sass, ['styles']);
    gulp.watch(paths.typescript, ['typescript']);
    gulp.watch(paths.typescriptChatRoom, ['typescriptChatRoom']);
});

//compiles sass files in the given location
gulp.task('typescript', function () {
    return gulp.src(paths.typescript)
		.pipe(ts({
		    noImplicitAny: true,
		    out: 'site.js'
		}))
		.pipe(gulp.dest(paths.js));
});

//compiles sass files in the given location
gulp.task('typescriptChatRoom', function () {
    return gulp.src(paths.typescriptChatRoom)
		.pipe(ts({
		    noImplicitAny: true,
		    out: 'chatroom.js'
		}))
		.pipe(gulp.dest(paths.js));
});

//bundles files
gulp.task('bundle', function() {
        return gulp.src('./bundle.config.js')
            .pipe(bundle())
            .pipe(bundle.results({
                pathPrefix: '/public/'
            }))
    .pipe(gulp.dest('./public'));
});