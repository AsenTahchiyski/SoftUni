define(['Q', 'requester', 'bookController'], function (Q, requester, bookController) {
    return (function () {
        var thisRequester = requester.config('kid_WJDMgxMaCx', '5791d61c584041a19a6ea1e78791ec94');
        var books = new bookController(thisRequester);

        function GetAllBooks() {
            var defer = Q.defer();
            books.getAll().then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        }

        function EditBook(id, book) {
            var defer = Q.defer();

            books.edit(id, book).then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        }

        function AddBook(book) {
            var defer = Q.defer();
            books.add(book).then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        }

        function DeleteBook(id) {
            var defer = Q.defer();
            books.delete(id).then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        }

        return {
            GetAllBooks: GetAllBooks,
            EditBook: EditBook,
            AddBook: AddBook,
            DeleteBook: DeleteBook
        }
    })();
});