$(document).ready(function () {
    var input = $('input');
    var button = $('button');
    var articles = $('.articles');
    var search = " ";
    var searchUrl = 'https://en.wikipedia.org/w/api.php';

    button.click(function () {
        articles.empty();
        search = input.val();
        ajaxArticleData();
    });

    var ajaxArticleData = function () {
        $.ajax({
            type: 'GET',
            dataType: 'jsonp',
            url: searchUrl,
            data: {
                action: 'query',
                format: 'json',
                prop: 'extracts',
                explaintext: true,
                exintro: true,
                exlimit: 'max',
                //titles: search,
                generator: 'search',
                gsrsearch: search,
                gsrnamespace: 0,
                gsrlimit: 10,

            },
            success: function (json) {
                var pages = json.query.pages;
                $.map(pages, function (page) {
                    var pageElement = $('<div>');

                    //get the article title
                    pageElement.append($('<h2>').text(page.title));

                    //get the article text
                    pageElement.append($('<p>').text(page.extract));

                    pageElement.append($('<hr>'));

                    articles.append(pageElement);
                });
            }
        })
    };
});