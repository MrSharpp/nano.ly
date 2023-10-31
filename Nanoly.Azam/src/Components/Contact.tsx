import { Link } from "react-router-dom";
const Contact = () => {
  return (
    <>
      <header>
        <a href="#">Logo</a>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="about">About</Link>
            </li>
            <li>
              <Link to="contact">Contact</Link>
            </li>
          </ul>
        </nav>
      </header>
      <section>
        <p>Welcome to Contact Us Page!</p>
      </section>
    </>
  );
};

export default Contact;
