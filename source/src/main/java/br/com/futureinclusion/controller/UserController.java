package br.com.futureinclusion.controller;

import java.util.List;

import br.com.futureinclusion.dao.UserDAO;
import br.com.futureinclusion.entity.User;

public class UserController extends Controller implements IController<User> {

	UserDAO myDao;
	
	UserController(){
		this.myDao = new UserDAO(this.entityManager);
	}
	
	public void Save(User model) {
		try {
			myDao.save(model, true);
		} catch (Exception e) {
			e.printStackTrace();
			entityManager.getTransaction().rollback();
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
	}
	
	public void Delete(Integer id) {
		try {
			myDao.delete(id, true);
		} catch (Exception e) {
			e.printStackTrace();
			entityManager.getTransaction().rollback();
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
	}
	
	public User GetOne(Integer id) {
		return this.myDao.get(id);
	}
	
	public List<User> GetAll() {
		return this.myDao.getAll();
	}

}
