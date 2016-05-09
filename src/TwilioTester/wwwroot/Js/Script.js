$(document).ready(function () {
    var input = $('input');
    var button = $('.wiki');
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

    var SimpleListModel = function (items) {
        this.items = ko.observableArray(items);
        this.itemToAdd = ko.observable("");
        this.addItem = function () {
            if (this.itemToAdd() != "") {
                this.items.push(this.itemToAdd()); // Adds the item. Writing to the "items" observableArray causes any associated UI to update.
                this.itemToAdd(""); // Clears the text box, because it's bound to the "itemToAdd" observable
            }
        }.bind(this);  // Ensure that "this" is always this view model
    };

    ko.applyBindings(new SimpleListModel([]), document.getElementById('form'));

    var testObject = {
        name: 'law',
        age: 32
    };
    //for multiple view-models on View use: ko.applyBindings(myViewModel, document.getElementById('someElementId')).

    ko.applyBindings(testObject, document.getElementById('123'));

});
