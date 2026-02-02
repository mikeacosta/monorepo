
import { Grid } from "@mui/material"
import GimmicksList from "./GimmicksList"
import GimmickDetails from "../details/GimmickDetails"
import GimmickForm from "../form/GimmickForm"

type Props = {  
  gimmicks: Gimmick[]
  selectedGimmick: Gimmick | undefined
  selectGimmick: (id: string) => void 
  cancelSelect: () => void
  openForm: (id: string) => void
  closeForm: () => void
  editMode: boolean
  deleteGimmick: (id: string) => void
}

const GimmicksDashboard = ({ gimmicks, selectedGimmick, selectGimmick, cancelSelect, openForm, closeForm, editMode, deleteGimmick }: Props) => {
  return (
    <Grid container spacing={3}>
      <Grid size={7}>
        <GimmicksList 
          gimmicks={gimmicks} 
          selectGimmick={selectGimmick}
          deleteGimmick={deleteGimmick}
        />
      </Grid>
      <Grid size={5}>
        {selectedGimmick && !editMode &&
        <GimmickDetails 
          gimmick={selectedGimmick}
          cancelSelect={cancelSelect}
          openForm={openForm}
        />}
        {editMode &&
        <GimmickForm 
          gimmick={selectedGimmick} 
          closeForm={closeForm} />
        }
      </Grid>
    </Grid>
  )
}

export default GimmicksDashboard