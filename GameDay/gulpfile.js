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


gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean:jsmap", function (cb) {
    rimraf(paths.concatJsMapDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css", "clean:jsmap"]);



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
gulp.task('watch', function () {
    gulp.watch(paths.sass, ['styles']);
    gulp.watch(paths.typescript, ['typescript']);
    gulp.watch(paths.typescriptChatRoom, ['typescriptChatRoom']);
});

gulp.task('typescript', function () {
    return gulp.src(paths.typescript)
		.pipe(ts({
		    noImplicitAny: true,
		    out: 'site.js'
		}))
		.pipe(gulp.dest(paths.js));
});

gulp.task('typescriptChatRoom', function () {
    return gulp.src(paths.typescriptChatRoom)
		.pipe(ts({
		    noImplicitAny: true,
		    out: 'chatroom.js'
		}))
		.pipe(gulp.dest(paths.js));
});

gulp.task('bundle', function() {
        return gulp.src('./bundle.config.js')
            .pipe(bundle())
            .pipe(bundle.results({
                pathPrefix: '/public/'
            }))
    .pipe(gulp.dest('./public'));
});