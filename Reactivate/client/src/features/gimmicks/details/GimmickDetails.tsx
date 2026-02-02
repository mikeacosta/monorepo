import { Card, CardMedia, CardContent, Typography, CardActions, Button } from "@mui/material"

type Props = {
  gimmick: Gimmick
  cancelSelect: () => void
  openForm: (id: string) => void
}

const GimmickDetails = ({ gimmick, cancelSelect, openForm }: Props) => {
  return (
    <Card sx={{ borderRadius: 3 }}>
      <CardMedia
        component='img'
        src={`/images/categoryImages/${gimmick.category}.jpg`}
      />
      <CardContent>
        <Typography variant="h5">{gimmick.title}</Typography>
        <Typography variant="subtitle1" fontWeight='light'>{gimmick.date}</Typography>
        <Typography variant="body1">{gimmick.description}</Typography>
      </CardContent>
      <CardActions>
        <Button onClick={() => openForm(gimmick.id)} color="primary">Edit</Button>
        <Button onClick={cancelSelect} color='inherit'>Cancel</Button>
      </CardActions>
    </Card>
  )
}
export default GimmickDetails