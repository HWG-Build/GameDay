module.exports = {
    bundle: {
        main: {
            scripts: [
                "~/Scripts/js/site.js"
            ],
            styles: [
            //'./content/**/*.css',
            "~/lib/bootstrap/dist/css/bootstrap.css",
            "~/lib/bootstrap/dist/css/bootstrap-theme.css",
            "~/lib/bootstrap-tagsinput/dist/bootstrap-tagsinput.css",
            "~/Content/site.css"
            ]
        },
        vendor: {
          scripts: [
                "~/lib/jquery/dist/jquery.js",
                "~/lib/bootstrap/dist/js/bootstrap.js",
                "~/lib/jquery-ui/jquery-ui.js",
                "~/Scripts/jquery.signalR-2.1.2.js",
                "~/lib/bootstrap-tagsinput/dist/bootstrap-tagsinput.js"
          ]
        }
    },
    copy: './content/**/*.{png,jpg}'
};