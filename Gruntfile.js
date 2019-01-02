module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        
        clean: {
            Content: [
            'IdentityApplication/Content/**/*',
            '!IdentityApplication/Content/images/**/*',
            '!IdentityApplication/Content/images'
            ]
        },

        // Compile SASS files into minified CSS.
        sass: {
            options: {
                // bootstrap SCSS files to use with @import.
                // An array of paths that LibSass can look in to attempt to resolve your @import declarations.
                includePaths: ['bower_components/bootstrap-sass/assets/stylesheets', 'IdentityApplication/scss/include']
            },
            dist: {
                options: {
                    //outputStyle: 'compressed'
                },
                // the file that i want to compile. eg, 'dist/compiled.css' : 'scss/source.scss'
                files: {
                    'IdentityApplication/Content/application.css': 'IdentityApplication/scss/application.scss'
                }
            }
        },

        // Copy web assets from bower_components to more convenient directories.
        copy: {
            main: {
                files: [
                    ////////////////////// Vendor scripts.

                    //bootstrap-sass
                    {
                        expand: true,
                        cwd: 'bower_components/bootstrap-sass/assets/javascripts/',
                        src: ['**/*.js'],
                        dest: 'IdentityApplication/Content/bootstrap-sass/'
                    },

                    //jquery
                    {
                        expand: true,
                        cwd: 'bower_components/jquery/dist/',
                        src: ['**/*.js', '**/*.map'],
                        dest: 'IdentityApplication/Content/jquery/'
                    },

                    //jquery.validation
                    {
                        expand: true,
                        cwd: 'bower_components/jquery.validation/dist/',
                        src: ['**/*.js'],
                        dest: 'IdentityApplication/Content/jquery.validation/'
                    },

                    // Microsoft.jQuery.Unobtrusive.Validation
                    {
                        expand: true,
                        cwd: 'bower_components/Microsoft.jQuery.Unobtrusive.Validation/',
                        src: ['**/*.js'],
                        dest: 'IdentityApplication/Content/Microsoft.jQuery.Unobtrusive.Validation/'
                    },

                    // Fonts.
                    {
                        expand: true,
                        filter: 'isFile',
                        flatten: true,
                        cwd: 'bower_components/',
                        src: ['bootstrap-sass/assets/fonts/**'],
                        dest: 'IdentityApplication/Content/fonts/bootstrap/'
                    },

                    // site images.
                    //{
                    //    expand: true,
                    //    src: ['site_images/**'],
                    //    dest: 'IdentityApplication/Content/'
                    //},
                ]
            },
        },

        // Watch these files and notify of changes.
        //watch: {
        //    grunt: { files: ['Gruntfile.js'] },
        //
        //    sass: {
        //        files: [
        //            'IdentityApplication/scss/**/*.scss'
        //        ],
        //        tasks: ['sass']
        //    }
        //}
    });

    // Load externally defined tasks. 
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-sass'); // maybe should be using grunt-contrib-sass
    //grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-copy');


    // Establish tasks we can run from the terminal.
    grunt.registerTask('default', ['clean', 'copy', 'sass']); // must copy first. so that sass will be able to build
    //grunt.registerTask('build', ['clean', 'copy', 'sass']);
    //grunt.registerTask('default', ['clean', 'build', 'watch']);
}