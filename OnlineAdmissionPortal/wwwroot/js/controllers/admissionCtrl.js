angular.module('pageApp', ['bw.paging']);
angular.module('app').requires.push('pageApp');
app.controller("admissionCtrl", ['$scope', 'admissionData', function ($scope, admissionData) {

    $scope.selectedStudent = {};
    $scope.studentFilter = {};;

    //Getting studens
    $scope.getStudents = function (filter) {
        admissionData.getStudents(filter).then(function (resp) {
            $scope.studentList = resp.data;
            if (resp.data && resp.data.length > 0) {
                $scope.pageSize = resp.data[0].pageSize;
                $scope.currentPage = resp.data[0].currentPage;
                $scope.page = resp.data[0].currentPage;
                $scope.total = resp.data[0].totalRecord;
                $scope.totalRecord = resp.data[0].totalRecord;

            } else {
                $scope.totalStudents = 0;
                $scope.totalRecord = 0;
            }
        })
    };

    //clear filter 
    $scope.clearFilter = function (filter) {
        $scope.selectedStudent = {};
        $scope.studentFilter.currentPage = filter.currentPage;
        $scope.studentFilter.pageSize = filter.pageSize;
        $scope.getStudents($scope.studentFilter);
    };

    //Selecting studen details for deleting records
    $scope.studentDelete = function (studenId) {
        $("#deleteMember").modal("show");
        $scope.studenId = studenId;
    };

    //Deleting studen
    $scope.deleteStudent = function () {
        admissionData.deleteStuden($scope.id).then(function (result) {
            $scope.data = result.data;
            $scope.message = $scope.data.message;
            $scope.isValid = result.data.isValid;
            $("#deleteMember").modal("hide");
            $scope.modalPopup();
        });
    };

    //Selecting studen details for editing records
    $scope.studenEdit = function (item) {
        $scope.studenDetails = {};
        angular.extend($scope.studenDetails, item);
        $("#editMember").modal("show");
    };

    //update studen details
    $scope.updateStudent = function (studenDetails) {
        $scope.selectedStudent = studenDetails;
        admissionData.updateStudent($scope.selectedStudent).then(function (result) {
            $("#editMember").modal("hide");
            $scope.data = result.data;
            $scope.message = $scope.data.message;
            $scope.isValid = result.data.isValid;
            $scope.modalPopup();
        });
    };

    //success message popup
    $scope.modalPopup = function () {
        if ($scope.message !== undefined) {
            $("#successMsg").modal("show");
        }
        $scope.getStudents($scope.studentFilter);
    }


}]);
