'use strict';
applicationModule.factory('chatHub', ['$rootScope', 'Hub' , function ($rootScope, hub) {
    var h = new hub('chatHub', {
        listeners: {
            'groupMessage': function(m, r, u) {
                $rootScope.$emit('NewMessage', { message: m, room: r, user: u });
            },
        },
        methods: ['joinRoom', 'send'],
        errorHandler: function (error) {
            log("chatHub error");
            log(error);
        }
    });

    return {
        joinRoom: function(room) {
            h.joinRoom(room, "foo");
        },
        send: function(m, room) {
            h.send(m, room, "foo");
        }    
    }
}]);