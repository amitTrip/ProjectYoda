
console.log("CPE Detail List");

angular.module("Yoda").register.controller('CPEDetailListController', ['$routeParams', '$location', 'ajaxService', 'dataGridService', 'alertService',
    function ($routeParams, $location, ajaxService, dataGridService, alertService) {

    "use strict";

    var vm = this;

    this.initializeController = function () {

        vm.title = "CPE Detail List 1";

        vm.alerts = [];
        vm.closeAlert = alertService.closeAlert;

        dataGridService.initializeTableHeaders();

        dataGridService.addHeader("SR Number", "SRNumber");
        dataGridService.addHeader("Review Month", "ReviewMonth");
        dataGridService.addHeader("Engineer Name", "EngineerName");
        dataGridService.addHeader("POD Name", "PODName");
        dataGridService.addHeader("Qos", "QoS");

        vm.tableHeaders = dataGridService.setTableHeaders();
        vm.defaultSort = dataGridService.setDefaultSort("SR Number");

        vm.currentPageNumber = 1;
        vm.sortExpression = "SRNumber";
        vm.sortDirection = "ASC";
        vm.pageSize = 15;
        console.log("CPE Detail Pre Post");
        debugger;
        this.executeInquiry();

    }

    this.closeAlert = function (index) {
        vm.alerts.splice(index, 1);
    };

    this.changeSorting = function (column) {

        dataGridService.changeSorting(column, vm.defaultSort, vm.tableHeaders);

        vm.defaultSort = dataGridService.getSort();
        vm.sortDirection = dataGridService.getSortDirection();
        vm.sortExpression = dataGridService.getSortExpression();
        vm.currentPageNumber = 1;

        vm.executeInquiry();

    };

    this.setSortIndicator = function (column) {
        return dataGridService.setSortIndicator(column, vm.defaultSort);
    };

    this.pageChanged = function () {
        this.executeInquiry();
    }

    this.executeInquiry = function () {
        var inquiry = vm.prepareSearch();
        console.log("CPE Detail List POST");
        ajaxService.ajaxPost(inquiry, "api/CPEDetailService/GetCPEDetails", this.getCPEDetailsOnSuccess, this.getCPEDetailsOnError);
    }

    this.prepareSearch = function () {

        var inquiry = new Object();
      
        inquiry.currentPageNumber = vm.currentPageNumber;
        inquiry.sortExpression = vm.sortExpression;
        inquiry.sortDirection = vm.sortDirection;
        inquiry.pageSize = vm.pageSize;
        
        return inquiry;

    }

    this.getCPEDetailsOnSuccess = function (response) {
        vm.CPEDetails = response.CPEDetails;
        vm.totalCPEDetails = response.totalRows;
        vm.totalPages = response.totalPages;
    }

    this.getCPEDetailsOnError = function (response) {
        alertService.RenderErrorMessage(response.ReturnMessage);
    }


}]);
