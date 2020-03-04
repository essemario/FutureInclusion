package br.com.futureinclusion.controller;

import java.util.List;

import br.com.futureinclusion.dao.VoterDAO;
import br.com.futureinclusion.entity.Voter;

public class VoterController extends Controller implements IController<Voter> {

	VoterDAO myDao;
	
	VoterController(){
		this.myDao = new VoterDAO(this.entityManager);
	}
	
	public void Save(Voter model) {
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
	
	public Voter GetOne(Integer id) {
		return this.myDao.get(id);
	}
	
	public List<Voter> GetAll() {
		return this.myDao.getAll();
	}
}