package entity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;
import java.util.List;


/**
 * The persistent class for the Mandate database table.
 * 
 */
@Entity
@NamedQuery(name="Mandate.findAll", query="SELECT m FROM Mandate m")
public class Mandate implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private int id;

	private byte active;

	@Temporal(TemporalType.DATE)
	@Column(name="end_date")
	private Date endDate;

	@Temporal(TemporalType.DATE)
	@Column(name="start_date")
	private Date startDate;

	private String title;

	private byte validated;

	@Temporal(TemporalType.DATE)
	@Column(name="validated_date")
	private Date validatedDate;

	//bi-directional many-to-one association to City
	@ManyToOne
	private City city;

	//bi-directional many-to-one association to Country
	@ManyToOne
	private Country country;

	//bi-directional many-to-one association to Power
	@ManyToOne
	private Power power;

	//bi-directional many-to-one association to State
	@ManyToOne
	private State state;

	//bi-directional many-to-many association to Voter
	@ManyToMany
	@JoinColumn(name="id")
	private List<Voter> voters;

	//bi-directional many-to-one association to Poll
	@OneToMany(mappedBy="mandate")
	private List<Poll> polls;

	//bi-directional many-to-one association to Post
	@OneToMany(mappedBy="mandate")
	private List<Post> posts;

	//bi-directional many-to-one association to User
	@OneToMany(mappedBy="mandate")
	private List<User> users;

	public Mandate() {
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public byte getActive() {
		return this.active;
	}

	public void setActive(byte active) {
		this.active = active;
	}

	public Date getEndDate() {
		return this.endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public Date getStartDate() {
		return this.startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public String getTitle() {
		return this.title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public byte getValidated() {
		return this.validated;
	}

	public void setValidated(byte validated) {
		this.validated = validated;
	}

	public Date getValidatedDate() {
		return this.validatedDate;
	}

	public void setValidatedDate(Date validatedDate) {
		this.validatedDate = validatedDate;
	}

	public City getCity() {
		return this.city;
	}

	public void setCity(City city) {
		this.city = city;
	}

	public Country getCountry() {
		return this.country;
	}

	public void setCountry(Country country) {
		this.country = country;
	}

	public Power getPower() {
		return this.power;
	}

	public void setPower(Power power) {
		this.power = power;
	}

	public State getState() {
		return this.state;
	}

	public void setState(State state) {
		this.state = state;
	}

	public List<Voter> getVoters() {
		return this.voters;
	}

	public void setVoters(List<Voter> voters) {
		this.voters = voters;
	}

	public List<Poll> getPolls() {
		return this.polls;
	}

	public void setPolls(List<Poll> polls) {
		this.polls = polls;
	}

	public Poll addPoll(Poll poll) {
		getPolls().add(poll);
		poll.setMandate(this);

		return poll;
	}

	public Poll removePoll(Poll poll) {
		getPolls().remove(poll);
		poll.setMandate(null);

		return poll;
	}

	public List<Post> getPosts() {
		return this.posts;
	}

	public void setPosts(List<Post> posts) {
		this.posts = posts;
	}

	public Post addPost(Post post) {
		getPosts().add(post);
		post.setMandate(this);

		return post;
	}

	public Post removePost(Post post) {
		getPosts().remove(post);
		post.setMandate(null);

		return post;
	}

	public List<User> getUsers() {
		return this.users;
	}

	public void setUsers(List<User> users) {
		this.users = users;
	}

	public User addUser(User user) {
		getUsers().add(user);
		user.setMandate(this);

		return user;
	}

	public User removeUser(User user) {
		getUsers().remove(user);
		user.setMandate(null);

		return user;
	}

}