package dao;

import javax.persistence.*;

import entity.*;

public class ImageDAO extends GenericDAO<Image, Integer> {

	public ImageDAO(EntityManager entityManagerParam) {
		super(entityManagerParam);
	}
}