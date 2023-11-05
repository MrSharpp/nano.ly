import { useParams } from "react-router-dom";
const UserDetails = () => {
  const { id } = useParams();
  return (
    <>
      <section>
        <h1
          style={{
            color: "darkblue",
            fontSize: 25,
            fontWeight: "lighter",
            margin: "1.5rem",
            fontStyle: "italic",
          }}
        >
          Details about User {id}
        </h1>
      </section>
    </>
  );
};
export default UserDetails;
