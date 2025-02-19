angular.module('pageApp', ['bw.paging']);
angular.module('app').requires.push('pageApp');

app.controller("admissionCtrl", ['$scope', 'admissionData', function ($scope, admissionData) {

    $scope.selectedStudent = {};
    $scope.studentFilter = {};
    $scope.selectedInstitute = {};
    $scope.instituteFilter = {};

    /*** STUDENT METHODS ***/

    // Students को प्राप्त करने का method
    $scope.getStudents = function (filter) {
        admissionData.getStudents(filter).then(function (resp) {
            $scope.studentList = resp.data;
            if (resp.data && resp.data.length > 0) {
                let data = resp.data[0];
                $scope.pageSize = data.pageSize;
                $scope.currentPage = data.currentPage;
                $scope.page = data.currentPage;
                $scope.totalRecord = data.totalRecord;
            } else {
                $scope.totalRecord = 0;
            }
        });
    };

    // Filter को साफ़ करने का method
    $scope.clearStudentFilter = function () {
        $scope.selectedStudent = {};
        $scope.studentFilter = {}; // Reset filters
        $scope.getStudents($scope.studentFilter);
    };

    // Student डिलीट करने के लिए ID सेट करना
    $scope.studentDelete = function (studentId) {
        $("#deleteMember").modal("show");
        $scope.studentId = studentId;
    };

    // Student को डिलीट करने का method
    $scope.deleteStudent = function () {
        admissionData.deleteStudent($scope.studentId).then(function (result) {
            $scope.message = result.data.message;
            $scope.isValid = result.data.isValid;
            $("#deleteMember").modal("hide");
            $scope.modalPopup();
        });
    };

    // Student को एडिट करने के लिए डिटेल्स सेट करना
    $scope.studentEdit = function (item) {
        $scope.studentDetails = angular.copy(item);
        $("#editMember").modal("show");
    };

    // Student को अपडेट करने का method
    $scope.updateStudent = function (studentDetails) {
        admissionData.updateStudent(studentDetails).then(function (result) {
            $("#editMember").modal("hide");
            $scope.message = result.data.message;
            $scope.isValid = result.data.isValid;
            $scope.modalPopup();
        });
    };

    /*** INSTITUTE METHODS ***/

    // Institutes को प्राप्त करने का method
    $scope.getInstitutes = function (filter) {
        admissionData.getInstitutes(filter).then(function (resp) {
            $scope.instituteList = resp.data;
            if (resp.data && resp.data.length > 0) {
                let data = resp.data[0];
                $scope.institutePageSize = data.pageSize;
                $scope.instituteCurrentPage = data.currentPage;
                $scope.instituteTotalRecord = data.totalRecord;
            } else {
                $scope.instituteTotalRecord = 0;
            }
        });
    };

    // Filter को साफ़ करने का method
    $scope.clearInstituteFilter = function () {
        $scope.selectedInstitute = {};
        $scope.instituteFilter = {}; // Reset filters
        $scope.getInstitutes($scope.instituteFilter);
    };

    // Institute डिलीट करने के लिए ID सेट करना
    $scope.instituteDelete = function (instituteId) {
        $("#deleteInstitute").modal("show");
        $scope.instituteId = instituteId;
    };

    // Institute को डिलीट करने का method
    $scope.deleteInstitute = function () {
        admissionData.deleteInstitute($scope.instituteId).then(function (result) {
            $scope.message = result.data.message;
            $scope.isValid = result.data.isValid;
            $("#deleteInstitute").modal("hide");
            $scope.modalPopup();
        });
    };

    // Institute को एडिट करने के लिए डिटेल्स सेट करना
    $scope.instituteEdit = function (item) {
        $scope.instituteDetails = angular.copy(item);
        $("#editInstitute").modal("show");
    };

    // Institute को अपडेट करने का method
    $scope.updateInstitute = function (instituteDetails) {
        admissionData.updateInstitute(instituteDetails).then(function (result) {
            $("#editInstitute").modal("hide");
            $scope.message = result.data.message;
            $scope.isValid = result.data.isValid;
            $scope.modalPopup();
        });
    };

    // Success message popup दिखाने का method
    $scope.modalPopup = function () {
        if ($scope.message) {
            $("#successMsg").modal("show");
        }
        $scope.getStudents($scope.studentFilter);
        $scope.getInstitutes($scope.instituteFilter);
    };

}]);
