@model Widgets.Models.ClaimMarketVoucher

@{
    ViewBag.Title = "ClaimMarketVoucher";
    Layout = "~/VGC.master"
}
<style>
    #background-image {
        background-image: url(/Images/SunwingVouchers.png);
        background-repeat: no-repeat;
        background-size: cover;
    }
</style>
<body id="background-image">
    <h2>Claim Your Voucher</h2>
    <form method="post" action="/widget/ClaimMarketVoucher">
        @Html.AntiForgeryToken()

        <div class="form-horizontal">
            <hr />
            @Html.ValidationSummary(true, "", new { @class = "text-danger" })

            <div class="form-group">
		<label class = "control-label col-md-2">First Name</label>
                @Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" })
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" })
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Email</label>
                <div class="col-md-10">
                    @Html.EditorFor(model => model.UserEmail, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.UserEmail, "", new { @class = "text-danger" })
                </div>
            </div>

            <div class="form-group">
                @Html.LabelFor(model => model.Gateway, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.EditorFor(model => model.Gateway, new { htmlAttributes = new { @class = "form-control" } })
                    @Html.ValidationMessageFor(model => model.Gateway, "", new { @class = "text-danger" })
                </div>
            </div>
            <div class="form-group">
                @Html.LabelFor(model => model.Agree, htmlAttributes: new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                        @Html.CheckBoxFor(model => model.Agree)
                        @Html.ValidationMessageFor(model => model.Agree, "", new { @class = "text-danger" })
                    </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-12">
                    <input type="submit" value="Claim Voucher" class="btn btn-success" />
                </div>
            </div>
            <div class="form-group" style="visibility:hidden">
                <div class="col-md-10">
                    @Html.EditorFor(model => model.VoucherId, new { htmlAttributes = new { @class = "form-control" } })
                </div>
            </div>
        </div>
    </form>
</body>
