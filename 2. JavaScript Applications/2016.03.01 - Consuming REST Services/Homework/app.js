(function () {
    require.config({
        baseUrl: '',
        paths: {
            'jQuery': 'lib/jquery-1.12.1.min',
            'Q': 'lib/q',
            'requester': 'js/controllers/requester',
            'userController': 'js/controllers/userController',
            'book': 'js/models/book',
            'bookController': 'js/controllers/bookController',
            'appController': 'js/controllers/appController'
        }
    })
})();

require(['book', 'appController', 'jQuery', 'userController', 'requester'], function (Book, appController, jQuery, userController, requester) {
    var books = [];
    var req = requester.config('kid_WJDMgxMaCx', '5791d61c584041a19a6ea1e78791ec94');
    var users = new userController(req);

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

    function loadBooks() {
        appController.GetAllBooks().then(function (success) {
            books = success;
            buildBooksDOM();

            //event listeners for editing books
            $('#bookEdit').on('click', function () {
                var book = books.filter(function (b) {
                    return b.name === $('bookEditInput').val();
                });
                if (book.length > 0) {
                    $('#bookEditName').val(book[0].name);
                    $('#bookEditOptions').css({'display': 'block'});
                }
            });
            $('#bookEditConfirm').on('click', function () {
                var book = books.filter(function (b) {
                    return b.name === $('#bookEditInput').val();
                });
                if (book.length > 0) {
                    book[0].title = $('#bookEditTitle').val();
                    book[0].author = $('#bookEditAuthor').val();
                    book[0].isbn = $('#bookEditIsbn').val();
                    appController.edit(book[0]._id, new Book(book[0].title, book[0].author, book[0].isbn)).then(function (editedBook) {
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
                        newBook.text(bookToAdd.title + ' by ' + bookToAdd.author + ' (ISBN: ' + bookToAdd.isbn + ')');
                        newBook.appendTo(ul);
                    });
                }
            });

            //event listener for deleting books
            $("#bookDelete").on("click", function () {
                var bookToDelete = books.filter(function (b) {
                    return b.name === $("#bookDeleteInput").val();
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

        //return allBooks;
    }

    function buildBooksDOM() {
        var booksContainer = $("#books");
        var booksUl = $("<ul>");
        booksContainer.empty();
        books.forEach(function (book) {
            var bookLi = $("<li>");
            bookLi.text("Title: " + book.title + "; Author: " + book.author + " (ISBN: " + book.isbn + ')');
            bookLi.attr("Author", book.author);
            bookLi.attr("ISBN", book.isbn);
            booksUl.append(bookLi);
        });

        booksUl.appendTo(booksContainer);
    }
});