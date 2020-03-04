package br.com.futureinclusion.controller;

import java.util.List;

public interface IController<T> {
	
	public void Save(T model);	
	public void Delete(Integer id);
	public T GetOne(Integer id);
	public List<T> GetAll();
	
}