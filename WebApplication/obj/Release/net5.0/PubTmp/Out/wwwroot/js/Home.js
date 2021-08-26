const VM = new Vue({
    el: '#app',
    data: {
        isCollapse: true,
        url: '../images/小新.jpg',
        srcList: [
            '../images/小新.jpg'
        ]
    }, methods: {
        handleOpen(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClose(key, keyPath) {
            console.log(key, keyPath);
        }
    }
});