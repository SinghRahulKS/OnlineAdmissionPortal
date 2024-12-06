app.factory('admissionData', ['$http', function ($http) {
    var service =
    {

        getStudents: function (model) {
            return $http.post('/Student/GetStudents/', model).then(function (data) {
                return data;
            });
        },
        deleteStudent: function (id) {
            return $http.post('/Student/Delete/' + id);
        },
        updateStudent: function (studenDetails) {
            return $http.post('/Student/Update/', studenDetails).then(function (data) {
                return data
            });
        },
        registerStudent: function (studenDetails) {
            return $http.post('/Student/RegisterStudent/', studenDetails).then(function (data) {
                return data
            });
        }
    }; return service;
}]);