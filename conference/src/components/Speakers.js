import { data } from "../../SpeakerData";
import SpeakersList from "./SpeakersList";
import Header from "./Header";

function Speakers() {
    return (
        <div className="container-fluid">
            <Header />
            <SpeakersList data={data} />
        </div>
    )
}

export default Speakers;