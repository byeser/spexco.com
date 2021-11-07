(function () {
    var link = document.querySelector("link[rel*='icon']") || document.createElement('link');
    document.head.removeChild(link);
    link = document.querySelector("link[rel*='icon']") || document.createElement('link');
    document.head.removeChild(link);
    link = document.createElement('link');
    link.type = 'image/x-icon';
    link.rel = 'shortcut icon';
    link.href = 'http://www.spexco.com/web/content/images/favicon.png';
    document.getElementsByTagName('head')[0].appendChild(link);
    document.title = " Swagger Spexco";
})();