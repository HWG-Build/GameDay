/// <binding BeforeBuild='clean, min, styles' />
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
    uglify = require("gulp-uglify"),
    util = require("gulp-util"),
    sass = require("gulp-sass");

var paths = {
    webroot: "./"
};

paths.js = paths.webroot + "Scripts/js/*.js";
paths.minJs = paths.webroot + "Scripts/js/*.min.js";
paths.css = paths.webroot + "Content/*.css";
paths.minCss = paths.webroot + "Content/*.min.css";
paths.concatJsDest = paths.webroot + "Scripts/js/site.min.js";
paths.concatCssDest = paths.webroot + "Content/site.min.css";
paths.sass = paths.webroot + "Content/*.scss";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);



gulp.task("min:js", function () {
    return gulp.src(paths.js)
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify({
            outSourceMap: true
}).on('error', util.log))
        .pipe(gulp.dest("./"));
});

gulp.task("min:css", function () {
    return gulp.src(paths.css)
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin().on('error', util.log))
        .pipe(gulp.dest("./"));
});

gulp.task("min", ["min:js", "min:css"]);


gulp.task('styles', function () {
    gulp.src(paths.sass)
        .pipe(sass().on('error', util.log))
        .pipe(gulp.dest('./Content/'));
});

//Watch task
gulp.task('watchSass', function () {
    gulp.watch(paths.sass, ['styles']);
});