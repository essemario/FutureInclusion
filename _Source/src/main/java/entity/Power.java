package entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


/**
 * The persistent class for the Power database table.
 * 
 */
@Entity
@NamedQuery(name="Power.findAll", query="SELECT p FROM Power p")
public class Power implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	private String name;

	//bi-directional many-to-one association to Mandate
	@OneToMany(mappedBy="power")
	private List<Mandate> mandates;

	//bi-directional many-to-one association to Sphere
	@ManyToOne
	private Sphere sphere;

	public Power() {
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

	public List<Mandate> getMandates() {
		return this.mandates;
	}

	public void setMandates(List<Mandate> mandates) {
		this.mandates = mandates;
	}

	public Mandate addMandate(Mandate mandate) {
		getMandates().add(mandate);
		mandate.setPower(this);

		return mandate;
	}

	public Mandate removeMandate(Mandate mandate) {
		getMandates().remove(mandate);
		mandate.setPower(null);

		return mandate;
	}

	public Sphere getSphere() {
		return this.sphere;
	}

	public void setSphere(Sphere sphere) {
		this.sphere = sphere;
	}

}