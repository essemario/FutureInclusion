const express = require('express');
const app = express();
const mongoose = require('mongoose');

//MOCK -> const usuarios = require('./usuarios');
mongoose.Promise = global.Promise;
mongoose.connect('mongodb://localhost:27017/futureinclusion', { 
    useNewUrlParser: true,
    useUnifiedTopology: true
})
.then(() => console.log("MongoDB conectado"))
.catch((err) => console.error("Erro ao conectar com o MongoDB "+err))

const Usuario = require('./models/usuario')

app.use(express.json())
app.use(express.urlencoded({ extended: true }))

// Cadastro
app.post('/Usuarios', function (req, res) {
    const data = req.body
    if(!data) {
        res.sendStatus(400)
    }
    new Usuario(data).save()
        .then(() => res.sendStatus(201))
        .catch(() => res.sendStatus(400))
});

// Listagem
app.get('/Usuarios', function (req, res) {
    Usuario.find()
         .then((usuarios) => res.send(usuarios))
         .catch(() => res.sendStatus(400));
});

// Leitura
app.get('/Usuarios/:id', function (req, res) {
    const usuarioId = req.params.id;
    Usuario.findById(usuarioId)
         .then((usuario) => res.send(usuario))
         .catch(() => res.sendStatus(400));
});

// Atualização
app.put('/Usuarios/:id', function (req, res) {
    const usuarioId = req.params.id;
    const data = req.body;
    if(!data || !usuarioId) {
        res.sendStatus(400)
    }
    
    Usuario.findByIdAndUpdate(usuarioId, data)
         .then(() => res.sendStatus(200))
         .catch(() => res.sendStatus(400));
});

// Deleção
app.delete('/Usuarios/:id', function (req, res) {
    const usuarioId = req.params.id;
    Usuario.findByIdAndRemove(usuarioId)
         .then(() => res.sendStatus(200))
         .catch(() => res.sendStatus(400));
});

app.listen(8080, () => {
    console.log('Servidor rodando em http://127.0.0.1:8080/');
});
