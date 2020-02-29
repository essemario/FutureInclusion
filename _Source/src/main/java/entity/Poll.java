package entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;
import java.util.List;


/**
 * The persistent class for the Poll database table.
 * 
 */
@Entity
@NamedQuery(name="Poll.findAll", query="SELECT p FROM Poll p")
public class Poll implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	@Lob
	private String description;

	@Temporal(TemporalType.TIMESTAMP)
	private Date end;

	private String name;

	@Temporal(TemporalType.TIMESTAMP)
	private Date start;

	private String tag;

	//bi-directional many-to-one association to Choice
	@OneToMany(mappedBy="poll")
	private List<Choice> choices;

	//bi-directional many-to-one association to Mandate
	@ManyToOne
	private Mandate mandate;

	//bi-directional many-to-one association to Post
	@OneToMany(mappedBy="poll")
	private List<Post> posts;

	public Poll() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getDescription() {
		return this.description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Date getEnd() {
		return this.end;
	}

	public void setEnd(Date end) {
		this.end = end;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Date getStart() {
		return this.start;
	}

	public void setStart(Date start) {
		this.start = start;
	}

	public String getTag() {
		return this.tag;
	}

	public void setTag(String tag) {
		this.tag = tag;
	}

	public List<Choice> getChoices() {
		return this.choices;
	}

	public void setChoices(List<Choice> choices) {
		this.choices = choices;
	}

	public Choice addChoice(Choice choice) {
		getChoices().add(choice);
		choice.setPoll(this);

		return choice;
	}

	public Choice removeChoice(Choice choice) {
		getChoices().remove(choice);
		choice.setPoll(null);

		return choice;
	}

	public Mandate getMandate() {
		return this.mandate;
	}

	public void setMandate(Mandate mandate) {
		this.mandate = mandate;
	}

	public List<Post> getPosts() {
		return this.posts;
	}

	public void setPosts(List<Post> posts) {
		this.posts = posts;
	}

	public Post addPost(Post post) {
		getPosts().add(post);
		post.setPoll(this);

		return post;
	}

	public Post removePost(Post post) {
		getPosts().remove(post);
		post.setPoll(null);

		return post;
	}

}