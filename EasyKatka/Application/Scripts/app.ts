/// <reference path="typings/jquery/jquery.d.ts" />
class AuctionTimer {
    public ticks = 312;

    update = () => {
        let minutes = Math.floor(this.ticks / 60);
        let seconds = this.ticks % 60;

        $('#auction-timer').text(`${minutes}:${seconds}`);
        this.ticks--;

        if (this.ticks >= 0) {
            setTimeout(this.update, 1000);
        }
    }
}

window.onload = () => {
    let auctionTimer = new AuctionTimer();
    auctionTimer.update();
}