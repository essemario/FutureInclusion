import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';

export default StyleSheet.create({

    header: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
    },

    headerIcons:{
       flexDirection: 'row',
    },
    
    profile: {
        alignItems: 'center',
    },


    logout :{
        alignItems: 'center',
        marginLeft: 30,
        marginRight: 8
    },
});