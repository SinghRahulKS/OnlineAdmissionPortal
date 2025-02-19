app.factory('userData', ['$http', function ($http) {
    var service =
    {

        getUsers: function (model) {
            return $http.post('/account/getUsers/', model).then(function (data) {
                return data;
            });
        },
        deleteUser: function (userId) {
            return $http.delete('/Account/Delete', { params: { userId: userId } })
                .then(function (response) {
                    return response;
                }).catch(function (error) {
                    console.error("Delete request failed:", error);
                });
        },

        updateUser: function (userDetails) {
            return $http.put('/Account/Edit/', userDetails)
                .then(function (response) {
                    return response;
                })
                .catch(function (error) {
                    console.error("Error updating user:", error);
                    return Promise.reject(error);
                });
        }

    }; return service;
}]);