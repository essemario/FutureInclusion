const mongoose = require('mongoose');
const UsuarioSchema = new mongoose.Schema({
    name: {
        type: String,
        required: true
    },
    email: {
        type: String,
        required: true
    },
    lastName: {
        type: String,
        required: true
    },
    level: {
        type: Number,
        required: true
    },
    password: {
        type: String
    },
    enabled: {
        type: Boolean
    }
});
mongoose.model('usuarios', UsuarioSchema);
module.exports = mongoose.model('usuarios');