import { data } from "../SpeakerData";
import Header from "../src/components/Header";
import SpeakersToolbar from "../src/components/SpeakersToolbar";
import SpeakersList from "../src/components/SpeakersList";

const IndexPage = () => {
  return (
    <div className="container-fluid">
      <Header />
      <SpeakersToolbar />
      <SpeakersList data={data} />
    </div>
  )
};

export default IndexPage;