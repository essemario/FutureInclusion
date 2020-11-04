class Usuario {
    constructor(id, name, email, lastName, password, level, enabled) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.lastName = lastName;
        this.password = password;
        this.level = level;
        this.enabled = enabled;
    }
  }
  
let usuarios = [
    new Usuario(2, 'Mario Cesar', 'mario@chapela.com.br', 'Chapela'    , '123'       , 0, true),
    new Usuario(3, 'Daniel'     , 'daniel@landuche.com' , 'Titio Zangs', '123123'    , 0, true),
    new Usuario(7, 'Victor'     , 'victor@miranda.com'  , 'Miranda'    , '1231512351', 0, true)
  ];

  function getAll() {
    return usuarios;
  }
  
  function getOne(index) {
    return usuarios[index];
  }
  
  function create(name, email, lastName, password, level, enabled) {
    usuarios.push(
        new Usuario(0, name, email, lastName, password, level, enabled)
    )
  }
  
  function update(name, email, lastName, password, level, enabled, indexUpdate) {
    let usuarioObject =  new Usuario(0, name, email, lastName, password, level, enabled);
    usuarios = usuarios.map((usuario, index) => {
        if (index == indexUpdate) {
          return usuarioObject;
        }
        return usuario;
    })
  }
  
  function deleteUsuario(indexDelete) {
    usuarios.splice(indexDelete, 1)
  }
  
  module.exports.getAll = getAll;
  module.exports.getOne = getOne;
  module.exports.create = create;
  module.exports.update = update;
  module.exports.delete = deleteUsuario;