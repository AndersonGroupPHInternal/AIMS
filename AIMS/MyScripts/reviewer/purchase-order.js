app.controller("myCtrl", function ($scope, $http) {
    $scope.requisition;
    $scope.initialize = function () {
        $scope.page;
        $scope.loadpage(1, true);
    }

    //======LOAD USERS IN PAGE========//
    $scope.pageChange = function (page) {
        $scope.page = page;
        $scope.loadpage(page.PageNumber, page.PageStatus);
    }

    $scope.loadpage = function (pagenumber, pagestatus) {
        var data = {
            pagenumber: pagenumber,
            pagestatus: pagestatus
        };
        $http.post("/Reviewer/DeliveryMonitoringPageData", data).then(
            function successCallback(response) {
                $scope.requisitions = response.data;
                //if ($scope.requisitions.length > 1) {
                //    text = 'You have (' + $scope.requisitions.length + ') new requisition/request received. Click here to view the details...';
                //} else {
                //    text = 'You have a new requisition/request received. Click here to view the details.';
                //}
                //if ($scope.requisitions.length != 0) {
                //    PNotify.desktop.permission();
                //    (new PNotify({
                //        title: 'New Notification',
                //        text: text,
                //        desktop: {
                //            desktop: true,
                //        }
                //    })).get().click(function (e) {
                //        PNotify.removeAll();
                //        if ($('.ui-pnotify-closer, .ui-pnotify-sticker, .ui-pnotify-closer *, .ui-pnotify-sticker *').is(e.target)) return;
                //    });
                //}
            },
            function errorCallback(response) {
            }
        );
        $http.post('/Reviewer/DeliveryMonitoringPages', data).then(
        function successCallback(response) {
            $scope.pages = response.data;
            if (!$scope.page) {
                $scope.page = $scope.pages[Object.keys($scope.pages)[0]];
            }
        },
        function errorCallback(response) {
        });
    }

    $scope.showViewModals = function (requisition) {
        $scope.requisition = angular.copy(requisition);
        var data =
            {
                requisition: requisition

            };
        $http.post("/Requisition/ViewPurchaseOrder", data).then(
            function successCallback(response) {
                $scope.partialRequisition = response.data;
                $scope.overTotal = 0;
                for (var item in $scope.partialRequisition[0].RequisitionItem) {
                    var x = $scope.partialRequisition[0].RequisitionItem[item];
                    $scope.overTotal += (x["Quantity"] * x["UnitPrice"]);
                }
                $("#viewModals").modal("show");
            },
            function errorCallback(response) {
            }
        );
    }

    //Close decline modal
    $scope.closeViewModal = function () {
        $("#viewModals").modal("hide");
    }


    //// Download a pdf
    //$scope.downloadPdf = function (supplierId) {
    //    var isOkay = true;
    //    if (supplierId !== undefined) {
    //        var data = {
    //            SupplierID: $scope.supplierx[0].SupplierID,
    //            SupplierName: $scope.supplierx[0].SupplierName,
    //            SupplierAddress: $scope.supplierx[0].Address,
    //            ContactPerson: $scope.supplierx[0].ContactPerson,
    //            ContactNo: $scope.supplierx[0].ContactNo,
    //            SupplierEmail: $scope.supplierx[0].Email,
    //            Vatable: $scope.supplierx[0].Vatable,
    //            WholdingTax: $scope.supplierx[0].WholdingTax,
    //            RequisitionID: $scope.requisition.RequisitionID,
    //            LocationName: $scope.requisition.LocationName,
    //            LocationAddress: $scope.requisition.LocationAddress,
    //            RequiredDate: $scope.requisition.RequiredDateString,
    //            RequisitionItems: $scope.requisitionItems,
    //            DeliveryCharge: $scope.deliveryCharge
    //        }
    //        $http.post('/Reviewer/DownloadPdf', data)
    //            .then(window.open('/Reviewer/PurchaseOrderPDF'));
    //    }
    //    else {
    //        toastr.warning("There must be no zero (0) value of unit price.", "Invalid Unit Price");
    //    }
    //    //} else {
    //    //    toastr.warning("There are no supplier that is selected. Please select one.", "Please select supplier");
    //    //}
    //}

    //Display supplier info modal
    $scope.SupplierInformation = function (item) {
        $scope.supplierInfo = item;
        var data = {
            SupplierID: $scope.supplierInfo.SupplierID
        }
        $http.post("/Reviewer/DisplaySupplierItem", data).then(
            function successCallback(response) {
                $scope.supplierItems = response.data;
                //$scope.requisition.SupplierID = $scope.supplier.SupplierId;
                //$scope.hasSupplier = true;
                //$scope.initialize();
                $("#supplierInfoModal").modal("show");
            },
            function errorCallback(response) {

            }
        );
    }

    //Close supplier info modal
    $scope.closeSupplierInfo = function () {
        $("#supplierInfoModal").modal("hide");
    }
});
