const VM = new Vue({
    el: '#app',
    data: {
        imageUrl: '',
        userInfo: []
    }, mounted() {
        this.load();
        var c = document.getElementById('canv');
        var $ = c.getContext('2d');
        var u = 0;


        var shift = function (x, y, z, w) {
            x = x || 123456789;
            y = y || 362436069;
            z = z || 521288629;
            w = w || 88675123;

            return function () {
                var s = x ^ (x << 11);
                x = y;
                y = z;
                z = w;
                w = (w ^ (w >>> 19)) ^ (s ^ (s >>> 8));
                return w;
            };
        }

        var go = function () {
            var sc, g, g1, i, j, p, x, y, z, w, a, cur,
                d = new Date() / 1000,
                rnd = shift(),
                rnd1 = d,
                rnd2 = 2.4,
                rnd3 = d * 0.2,
                rnd1c = Math.cos(rnd1),
                rnd1s = Math.sin(rnd1),
                rnd2c = Math.cos(rnd2),
                rnd2s = Math.sin(rnd2);

            c.width = window.innerWidth;
            c.height = window.innerHeight;
            sc = Math.max(c.width, c.height);
            $.translate(c.width * 0.5, c.height * 0.5);
            $.scale(sc, sc);

            g = $.createLinearGradient(-1, -2, 1, 2);
            g.addColorStop(0.0, 'hsla(' + u * 5 + ',90%,50%, 1)');
            g.addColorStop(0.5, 'hsla(0,0%,0%,1)');
            g.addColorStop(1.0, 'hsla(' + u + ',90%,50%, 1)');
            $.fillStyle = g;
            $.fillRect(-0.5, -0.5, 1, 1);

            $.rotate(rnd3 % Math.PI * 2);
            for (i = 0; i < 360; i += 1) {

                p = rnd();
                x = (p & 0xff) / 128 - 1;
                y = (p >>> 8 & 0xff) / 128 - 1;
                z = (p >>> 16 & 0xff) / 128 - 1;
                w = (p >>> 24 & 0xff) / 256;

                z += d * 0.5;
                z = (z + 1) % 2 - 1;

                a = (z + 1) * 0.5;
                if (a < 0.9) {
                    $.globalAlpha = a / 0.9;
                } else {
                    a -= 0.9;
                    $.globalAlpha = 1 - a / 0.1;
                }

                cur = x * rnd1c + y * rnd1s;
                y = x * rnd1s - y * rnd1c;
                x = cur;

                cur = y * rnd2c + z * rnd2s;
                z = y * rnd2s - z * rnd2c;
                y = cur;

                z -= 0.75;
                if (z >= 0) {
                    continue;
                }
                sc = 0.15 / z;
                x *= sc;
                y *= sc;

                $.save();
                g1 = $.createRadialGradient(1, -2, 2, 1, 2, 2);
                g1.addColorStop(0.0, 'hsla(' + u * 5 + ',95%,50%, .8)');
                g1.addColorStop(0.5, 'hsla(' + u * 5 + ',95%,50%, .4)');
                g1.addColorStop(1.0, 'hsla(' + u + ',95%,50%, .8)');
                $.fillStyle = g1;
                $.translate(x, y);
                $.scale(sc * 0.02, sc * 0.02);
                $.rotate(w * Math.PI * 2);
                $.beginPath();
                $.arc(2, 0, 1.2, 0, Math.PI * 2);
                $.rotate(Math.PI * 2 * 0.1);
                $.closePath();
                $.fill();
                $.restore();
            }
        };
        window.addEventListener('resize', function () {
            c.width = window.innerWidth;
            c.height = window.innerHeight;
        }, false);
        window.requestAnimFrame = (function () {
            return window.requestAnimationFrame ||
                window.webkitRequestAnimationFrame ||
                window.mozRequestAnimationFrame ||
                window.oRequestAnimationFrame ||
                window.msRequestAnimationFrame ||
                function (callback) {
                    window.setTimeout(callback, 1000 / 60);
                };
        })();
        var run = function () {
            window.requestAnimFrame(run);
            go();
            u -= .2;
        }
        run();
    }, methods: {
        async load() {
            const { data: res } = await axios.get("/PersonalInfo/GetPersonalInfo");
            res.data.birthday = this.formatDateTime(res.data.birthday);
            res.data.sex = this.isSex(res.data.sex);
            this.userInfo = res.data;
            console.log(res);
        }, formatDateTime(inputTime) {
            var date = new Date(inputTime);
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            m = m < 10 ? ('0' + m) : m;
            var d = date.getDate();
            d = d < 10 ? ('0' + d) : d;

            return y + '-' + m + '-' + d;
        }, isSex(is) {
            if (is)
                return "♂男"
            else
                return "♀女"
        },
        handleAvatarSuccess(res, file) {
            this.imageUrl = URL.createObjectURL(file.raw);
        },
        beforeAvatarUpload(file) {
            const isJPG = file.type === 'image/jpeg';
            const isLt2M = file.size / 1024 / 1024 < 2;
            if (!isJPG) {
                this.$message.error('上传头像图片只能是 JPG 格式!');
            }
            if (!isLt2M) {
                this.$message.error('上传头像图片大小不能超过 2MB!');
            }
            return isJPG && isLt2M;
        }
    }
})