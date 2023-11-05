import { useNavigate } from "react-router-dom";
const Home = () => {
  const navigate = useNavigate();
  return (
    <>
      <section style={{ padding: "1rem", textAlign: "center" }}>
        <h1 style={{ color: "darkblue", fontSize: 32 }}>Home Page!</h1>
        <button
          style={{
            padding: "0.8rem",
            backgroundColor: "white",
            color: "darkblue",
            borderRadius: "9px",
            fontSize: 22,
          }}
          onClick={() => {
            navigate("/order-summary");
          }}
        >
          Place Order
        </button>
      </section>
    </>
  );
};
export default Home;
