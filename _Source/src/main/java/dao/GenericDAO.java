package dao;
import java.lang.reflect.ParameterizedType;
import java.util.List;
import javax.persistence.EntityManager;

public abstract class GenericDAO<EntityType, PrimaryKeyType> {
	protected EntityManager entityManager;

	private Class<EntityType> clazz;
	
	@SuppressWarnings("all")
	public GenericDAO(EntityManager entityManagerParam) {
		this.entityManager = entityManagerParam;
		clazz = (Class<EntityType>) ((ParameterizedType) getClass().getGenericSuperclass()).getActualTypeArguments()[0];
	}
		
	public void save(EntityType entity) {
		entityManager.merge(entity);
	}
	public void save(EntityType entity, boolean autoCommit) throws Exception {
		save(entity);
		if(autoCommit) {
			commit();
		}
	}

	public void delete(PrimaryKeyType id) throws Exception {
		EntityType entity = get(id);
		if (entity == null){
			throw new Exception("Codigo invalido");
		}
		entityManager.remove(entity);
	}
	public void delete(PrimaryKeyType id, boolean autoCommit) throws Exception {
		delete(id);
		if(autoCommit) {
			commit();
		}
	}
	
	public List<EntityType> getAll(){
		return entityManager.createQuery("from " + clazz.getName(), clazz).getResultList();
	}

	public EntityType get(PrimaryKeyType id) {
		return entityManager.find(clazz, id);
	}

	public void commit() throws Exception {
		try{
			entityManager.getTransaction().begin();
			entityManager.getTransaction().commit();
		}catch(Exception e){
			if (entityManager.getTransaction().isActive()) {
				entityManager.getTransaction().rollback();
			}
			e.printStackTrace();
			throw new Exception("Erro no commit");
		}
	}
}
