app.controller("myCtrl", function ($scope, $http) {
    //Replacing codes
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
        $http.post("/Requisition/LoadPageDeliveredData", data).then( //Created the http.post of LoadPageDeliveredData on the Requisition Controller Directory
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
        $http.post('/Requisition/LoadDeliveredPages', data).then( //Created the http.post of LoadDeliveredPages on the Requisition Controller Directory
            function successCallback(response) {
                $scope.pages = response.data;
                if (!$scope.page) {
                    $scope.page = $scope.pages[Object.keys($scope.pages)[0]];
                }
            },
            function errorCallback(response) {
            });
    }




    $scope.showViewModal = function (requisition) {
        $scope.requisition = angular.copy(requisition);
        var data =
            {
                requisition: requisition
            };
        $http.post("/Reviewer/RequisitionItem", data).then(
            function successCallback(response) {
                $scope.requisitionItems = response.data;
                $scope.overTotal = 0;
                for (var item in $scope.requisitionItems) {
                    var x = $scope.requisitionItems[item];
                    $scope.overTotal += (x["Quantity"] * x["UnitPrice"]);
                }
                $("#viewModal").modal("show");
            },
            function errorCallback(response) {
            }
        );
    }

    //Close decline modal
    $scope.closeViewModal = function () {
        $("#viewModal").modal("hide");
    }

    //Display supplier info modal
    $scope.SupplierInformation = function (item) {
        $scope.supplierInfo = item;
        $("#supplierInfoModal").modal("show");
    }

    //Download a pdf
    $scope.downloadPdf = function (supplierId) {
        var isOkay = true;
        if (supplierId !== undefined) {
            //for (var i = 0; i < $scope.requisitionItems.length; i++) {
            //    if ($scope.requisitionItems[i].UnitPrice == 0) {
            //        isOkay = false;
            //    }
            //}
            //if (isOkay) {

            var data = {

                SupplierID: $scope.supplierx[0].SupplierID,
                SupplierName: $scope.supplierx[0].SupplierName,
                SupplierAddress: $scope.supplierx[0].Address,
                ContactPerson: $scope.supplierx[0].ContactPerson,
                ContactNo: $scope.supplierx[0].ContactNo,
                SupplierEmail: $scope.supplierx[0].Email,
                Vatable: $scope.supplierx[0].Vatable,
                WholdingTax: $scope.supplierx[0].WholdingTax,
                RequisitionID: $scope.requisition.RequisitionID,
                LocationName: $scope.requisition.LocationName,
                LocationAddress: $scope.requisition.LocationAddress,
                RequiredDate: $scope.requisition.RequiredDateString,
                RequisitionItems: $scope.requisitionItems,
                DeliveryCharge: $scope.deliveryCharge
            }
            $http.post('/Reviewer/DownloadPdf', data)
                .then(window.open('/Reviewer/PurchaseOrderPDF'));
        }
        else {
            toastr.warning("There must be no zero (0) value of unit price.", "Invalid Unit Price");
        }
        //} else {
        //    toastr.warning("There are no supplier that is selected. Please select one.", "Please select supplier");
        //}
    }

    //Close supplier info modal
    $scope.closeSupplierInfo = function () {
        $("#supplierInfoModal").modal("hide");
    }
});