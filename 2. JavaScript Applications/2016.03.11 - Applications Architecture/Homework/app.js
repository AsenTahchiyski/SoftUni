(function () {
    require.config({
        baseUrl: '',
        paths: {
            'jQuery': 'lib/jquery-1.12.1.min',
            'Q': 'lib/q',
            'Mustache': 'lib/mustache.min',
            'Sammy': 'lib/sammy-latest.min',
            'requester': 'js/helpers/requester',
            'userController': 'js/controllers/userController',
            'book': 'js/binding-models/book',
            'bookController': 'js/controllers/bookController',
            'appController': 'js/controllers/appController'
        }
    })
})();

require(['book', 'appController', 'jQuery', 'userController', 'requester', 'Sammy', 'Mustache'], function (Book, appController, jQuery, userController, requester, Sammy, Mustache) {
    var router = Sammy(function () {
        var books = [],
            req = requester.config('kid_WJDMgxMaCx', '5791d61c584041a19a6ea1e78791ec94'),
            users = new userController(req);

        this.get('#/', function () {
            users.login('pesho', '1234')
                .then(function () {
                    loadBooks().then(function (success) {
                        books = success;
                    }, function (error) {
                        console.error(error);
                    });
                }, function (error) {
                    console.error(error);
                });
        });

        function loadBooks() {
            appController.GetAllBooks().then(function (success) {
                books = success;
                buildBooksDOM();

                //event listeners for editing books
                $('#bookEdit').on('click', function () {
                    $('#bookEditOptions').css('display', 'block');
                    var bookNewName = $('#bookEditInput').val(),
                        book = books.filter(function (b) {
                            return b.title == bookNewName;
                        });

                    if (book.length > 0) {
                        $('#bookEditTitle').val(book[0].title);
                        $('#bookEditAuthor').val(book[0].author);
                        $('#bookEditISBN').val(book[0].isbn);
                        $('#bookEditOptions').css({'display': 'block'});
                    }
                });
                $('#bookEditConfirm').on('click', function () {
                    var editConfirmTitle = $('#bookEditInput').val();
                    var book = books.filter(function (b) {
                        return b.title == editConfirmTitle;
                    });
                    if (book.length > 0) {
                        book[0].title = $('#bookEditTitle').val();
                        book[0].author = $('#bookEditAuthor').val();
                        book[0].isbn = $('#bookEditISBN').val();
                        appController.EditBook(book[0]._id, book[0]).then(function (editedBook) {
                            $('#bookEditOptions').css({'display': 'none'});
                            var editedBookDOM = $('#' + editedBook._id);
                            editedBookDOM.text('Title: ' + editedBook.title);
                            editedBookDOM.attr('title', editedBook.title);
                        });
                    }
                });

                //event listener for adding books
                $("#bookAdd").on("click", function () {
                    var bookToAddTitle = $("#bookAddTitle").val();
                    var bookToAddAuthor = $("#bookAddAuthor").val();
                    var bookToAddIsbn = $("#bookAddIsbn").val();
                    if (bookToAddTitle && bookToAddAuthor && bookToAddIsbn) {
                        var bookToAdd = new Book(bookToAddTitle, bookToAddAuthor, bookToAddIsbn);
                        appController.AddBook(bookToAdd).then(function () {
                            books.push(bookToAdd);
                            var ul = $("#books ul");
                            var newBook = $("<li>");
                            newBook.text(bookToAdd.title + ' | ' + bookToAdd.author + ' (ISBN: ' + bookToAdd.isbn + ')');
                            newBook.appendTo(ul);
                        });
                    }
                });

                //event listener for deleting books
                $("#bookDelete").on("click", function () {
                    var bookDeleteName = $("#bookDeleteInput").val();
                    var bookToDelete = books.filter(function (b) {
                        return b.title == bookDeleteName;
                    });
                    if (bookToDelete.length > 0) {
                        appController.DeleteBook(bookToDelete[0]._id).then(function () {
                            books = books.filter(function (b) {
                                return b._id !== bookToDelete[0]._id;
                            });
                            var deletedBook = $("#" + bookToDelete[0]._id);
                            deletedBook.remove();
                        });
                    }
                });
            });
        }

        function buildBooksDOM() {
            var booksContainer = $("#books");
            $.get('templates/bookTemplate.html', function (template) {
                var content = Mustache.render(template, {books: books});
                booksContainer.html(content);
            });
        }
    });

    router.run('#/');
});