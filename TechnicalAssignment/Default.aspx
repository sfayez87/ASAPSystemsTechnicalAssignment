<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TechnicalAssignment._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div id="assetsGrid"></div>
                    <script>
                        $(function () {
                            var apiData = null;
                            $.ajax({
                                url: "http://localhost:51785/api/assets",
                                type: "GET",
                                dataType: "JSON",
                                async: false,
                                success: function (data) {
                                    apiData = data;
                                }
                            });

                            var gridDataSource = new kendo.data.DataSource({
                                data: apiData,
                                schema: {
                                    model: {
                                        fields: {
                                            AssetId: { type: "string" },
                                            AssetName: { type: "string" },
                                            ModelNumber: { type: "string" },
                                            Vendor: { type: "string" },
                                            Description: { type: "string" }
                                        }
                                    }
                                }
                            });
                            $("#assetsGrid").kendoGrid({
                                dataSource: gridDataSource,
                                height: 400,
                                pageable: true,
                                sortable: true,
                                filterable: true,
                                columns: [{
                                    field: "AssetId",
                                    title: "Asset #",
                                    width: 160
                                }, {
                                        field: "AssetName",
                                        title: "Asset Name",
                                    width: 160
                                }, {
                                        field: "ModelNumber",
                                        title: "Model #",
                                    width: 200
                                }, {
                                        field: "Vendor",
                                        title: "Vendor"
                                }, {
                                        field: "Description",
                                        title: "Description"
                                }]
                            });

                        });
        </script>
</asp:Content>
