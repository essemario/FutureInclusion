package entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the Sphere database table.
 * 
 */
@Entity
@NamedQuery(name="Sphere.findAll", query="SELECT s FROM Sphere s")
public class Sphere implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	private String name;

	//bi-directional many-to-one association to Power
	@OneToMany(mappedBy="sphere")
	private List<Power> powers;

	public Sphere() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public List<Power> getPowers() {
		return this.powers;
	}

	public void setPowers(List<Power> powers) {
		this.powers = powers;
	}

	public Power addPower(Power power) {
		getPowers().add(power);
		power.setSphere(this);

		return power;
	}

	public Power removePower(Power power) {
		getPowers().remove(power);
		power.setSphere(null);

		return power;
	}

}