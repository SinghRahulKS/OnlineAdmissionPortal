app.factory('userData', ['$http', function ($http) {
    var service =
    {

        getUsers: function (model) {
            return $http.post('/account/getUsers/', model).then(function (data) {
                return data;
            });
        },
        deleteUser: function (userId) {
            return $http.post('/Account/DeleteUser/' + userId);
        },
        updateUser: function (userDetails) {
            return $http.post('/Account/UpdateUser/', userDetails).then(function (data) {
                return data
            });
        }
    }; return service;
}]);