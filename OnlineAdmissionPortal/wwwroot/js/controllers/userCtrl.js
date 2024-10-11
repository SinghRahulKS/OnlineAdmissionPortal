angular.module('pageApp', ['bw.paging']);
angular.module('app').requires.push('pageApp');
app.controller("userCtrl", ['$scope', 'userData', function ($scope, userData) {
    $scope.selectedUser = {};
    $scope.userFilter = {};
    $scope.userRecordIds = [];

    //Getting users
    $scope.getUsers = function (filter) {
        userData.getUsers(filter).then(function (resp) {
            $scope.userList = resp.data;
            if (resp.data && resp.data.length > 0) {
                $scope.pageSize = resp.data[0].pageSize;
                $scope.currentPage = resp.data[0].currentPage;
                $scope.page = resp.data[0].currentPage;
                $scope.total = resp.data[0].totalRecord;
                $scope.totalRecord = resp.data[0].totalRecord;

            } else {
                $scope.totalUsers = 0;
                $scope.totalRecord = 0;
            }
        })
    };

    //clear filter 
    $scope.clearFilter = function (filter) {
        $scope.userFilter = {};
        $scope.userFilter.currentPage = filter.currentPage;
        $scope.userFilter.pageSize = filter.pageSize;
        $scope.getUsers($scope.userFilter);
    };

    //Selecting User details for deleting records
    $scope.userDelete = function (userId) {
        $("#deleteMember").modal("show");
        $scope.userId = userId;
    };

    //Deleting User
    $scope.deleteUser = function () {
        userData.deleteUser($scope.userId).then(function (result) {
            $scope.data = result.data;
            $scope.message = $scope.data.message;
            $scope.isValid = result.data.isValid;
            $("#deleteMember").modal("hide");
            $scope.modalPopup();
        });
    };

    //Selecting User details for editing records
    $scope.userEdit = function (item) {
        $scope.userDetails = {};
        angular.extend($scope.userDetails, item);
        $("#editMember").modal("show");
    };

    //update user details
    $scope.updateUser = function (userDetails) {
        $scope.selectedUser = userDetails;
        userData.updateUser($scope.selectedUser).then(function (result) {
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
        $scope.getUsers($scope.userFilter);
    }
}]);

