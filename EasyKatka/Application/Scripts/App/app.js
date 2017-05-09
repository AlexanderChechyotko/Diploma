"use strict";
/// <reference path="typings/jquery/jquery.d.ts" />
var auction_module_1 = require('./modules/auction.module');
window.onload = function () {
    var auction = new auction_module_1.Auction();
    $("#loadBtn").click(function () { auction.update(); });
};
//# sourceMappingURL=app.js.map