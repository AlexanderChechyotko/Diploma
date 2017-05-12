/// <reference path="typings/jquery/jquery.d.ts" />
var AuctionTimer = (function () {
    function AuctionTimer() {
        var _this = this;
        this.ticks = 312;
        this.update = function () {
            var minutes = Math.floor(_this.ticks / 60);
            var seconds = _this.ticks % 60;
            $('#auction-timer').text(minutes + ":" + seconds);
            _this.ticks--;
            if (_this.ticks >= 0) {
                setTimeout(_this.update, 1000);
            }
        };
    }
    return AuctionTimer;
}());
window.onload = function () {
    var auctionTimer = new AuctionTimer();
    auctionTimer.update();
};
//# sourceMappingURL=app.js.map