/// <binding AfterBuild='default' Clean='clean' />

var gulp = require('gulp');
var del = require('del');

var paths = {
    src: ['src/**/*.js', 'src/**/*.ts', 'src/**/*.map'],
    libs: ['node_modules/angular2/bundles/angular2.js',
       'node_modules/angular2/bundles/angular2-polyfills.js',
       'node_modules/systemjs/dist/system.src.js',
       'node_modules/rxjs/bundles/Rx.js']
};

gulp.task('lib', function () {
    gulp.src(paths.libs).pipe(gulp.dest('wwwroot/dist/lib'))
});

gulp.task('clean', function () {
    return del(['wwwroot/dist/**/*']);
});

gulp.task('default', ['lib'], function () {
    gulp.src(paths.src).pipe(gulp.dest('wwwroot/dist'))
});