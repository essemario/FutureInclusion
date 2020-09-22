import { StyleSheet } from 'react-native';
import Constants from 'expo-constants';

export default StyleSheet.create({
    container: {
        flex: 1,
        paddingHorizontal: 16,
        paddingTop: Constants.statusBarHeight + 20,
     },

     postList: {
        marginTop: 32,
     },

     post: {
        padding: 24,
        borderRadius: 8,
        backgroundColor: '#fff',
        marginBottom: 16,
     }, 

     personal: {
        flexDirection: 'row',
        alignItems: 'center',
     },

     avatar: {
        width: 60,
        height: 60,
        borderRadius: 30,
        marginRight: 12,
     },
    
     politicalName: {
         fontSize: 18,
         color: '#41414d',
         fontWeight: 'bold',
     },

     politicalOffice: {
        fontSize: 12,
        color: '#00B0F0',
        fontWeight: 'bold',
     },

     title: {
        marginTop: 8,
        marginBottom: 4,
        fontSize: 16,
        color: '#41414d',
        fontWeight: 'bold',
     },

     postVoting: {
         marginTop: 12,
         flexDirection: 'row',
         justifyContent: 'space-between',
         alignItems: 'center',
     },

     detailsButtonYes: {
         flexDirection: 'row',
         justifyContent: 'space-between',
         alignItems: 'center',
         paddingVertical: 8,
         paddingHorizontal: 45,
         borderRadius: 8,
         backgroundColor: "#b1ecd5",
     },

     detailsButtonNo: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        paddingVertical: 8,
        paddingHorizontal: 45,
        borderRadius: 8,
        backgroundColor: "#ffc0cb",
    },

    detailsButtonText: {
        fontSize: 14,
        fontWeight: 'bold',
    },
});