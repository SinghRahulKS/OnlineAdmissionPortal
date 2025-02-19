app.factory('admissionData', ['$http', function ($http) {
    var service = {

        /*** STUDENT METHODS ***/

        // सभी Students को प्राप्त करने का API Call
        getStudents: function (model) {
            return $http.post('/Student/GetStudents/', model).then(function (data) {
                return data;
            });
        },

        // Student को डिलीट करने का API Call
        deleteStudent: function (id) {
            return $http.post('/Student/Delete/' + id);
        },

        // Student को अपडेट करने का API Call
        updateStudent: function (studentDetails) {
            return $http.post('/Student/Update/', studentDetails).then(function (data) {
                return data;
            });
        },

        // नया Student रजिस्टर करने का API Call
        registerStudent: function (studentDetails) {
            return $http.post('/Student/RegisterStudent/', studentDetails).then(function (data) {
                return data;
            });
        },

        /*** INSTITUTE METHODS ***/

        // सभी Institutes को प्राप्त करने का API Call
        getInstitutes: function (model) {
            return $http.post('/Institution/GetAll/', model).then(function (data) {
                return data;
            });
        },

        // Institute को डिलीट करने का API Call
        deleteInstitute: function (id) {
            return $http.post('/Institute/Delete/' + id);
        },

        // Institute को अपडेट करने का API Call
        updateInstitute: function (instituteDetails) {
            return $http.post('/Institute/Update/', instituteDetails).then(function (data) {
                return data;
            });
        },

        // नया Institute जोड़ने का API Call
        registerInstitute: function (instituteDetails) {
            return $http.post('/Institute/RegisterInstitute/', instituteDetails).then(function (data) {
                return data;
            });
        }
    };

    return service;
}]);
