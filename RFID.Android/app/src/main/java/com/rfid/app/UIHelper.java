package com.rfid.app;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.media.AudioManager;
import android.media.SoundPool;
import android.media.ToneGenerator;
import android.os.Build;
import android.widget.Toast;

import androidx.annotation.Nullable;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;

public class UIHelper {
    public static final String DatabaseName = "rfiddb";

    public static final SimpleDateFormat formatDateLong = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
    public static final SimpleDateFormat formatDate = new SimpleDateFormat("dd/MM/yyyy");
    public static final SimpleDateFormat formatDateValue = new SimpleDateFormat("yyyy/MM/dd");
    public static final SimpleDateFormat formatDateShort = new SimpleDateFormat("dd/MM HH:mm:ss");
    public static final SimpleDateFormat formatDateLongT = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");

    public static ToneGenerator toneGenerator = null;

    public static final int soundSuccessBarcode = ToneGenerator.TONE_CDMA_SOFT_ERROR_LITE;
    public static final int soundSuccess = ToneGenerator.TONE_CDMA_SOFT_ERROR_LITE;
    public static final int soundError = ToneGenerator.TONE_CDMA_ALERT_NETWORK_LITE;
    public static final int soundBeep = ToneGenerator.TONE_PROP_BEEP;
    public static final int soundSuccessMilisecs = 100;  // milliseconds
    public static final int soundErrorMilisecs = 1000;   // milliseconds

    public static final String STT = "Stt";
    public static final String VALUETEXT = "ValueText";

    private static HashMap<Integer, Integer> soundMap = new HashMap<Integer, Integer>();
    private static SoundPool soundPool;
    private static float volumnRatio;
    private static AudioManager am;

    public static void initSound(Context cont) {
        soundPool = new SoundPool(10, AudioManager.STREAM_MUSIC, 5);
        soundMap.put(1, soundPool.load(cont, R.raw.barcodebeep, 1));
        soundMap.put(2, soundPool.load(cont, R.raw.serror, 1));
        am = (AudioManager) cont.getSystemService(cont.AUDIO_SERVICE);// AudioManager
    }

    /**
     */
    public static void playSound(int id) {
        float audioMaxVolumn = am.getStreamMaxVolume(AudioManager.STREAM_MUSIC); // AudioManager
        float audioCurrentVolumn = am.getStreamVolume(AudioManager.STREAM_MUSIC);// AudioManager
        volumnRatio = audioCurrentVolumn / audioMaxVolumn;
        try {
            soundPool.play(soundMap.get(id), volumnRatio,
                    volumnRatio, 1, 0,1);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public static void playSoundSuccess() {
        playSound(1);
    }


    public static void playSoundSuccessEx() {
        playSoundEx(soundSuccess, 100);
    }

    private static void playSoundEx(int soundId) {
        playSoundEx(soundId, 100);
    }

    public static void playSoundEx(int soundId, int durationMs) {
        try {
            if (soundId == 0) soundId = soundSuccess;
            //final ToneGenerator tg = new ToneGenerator(AudioManager.STREAM_NOTIFICATION, 100);
            if (toneGenerator == null)
                toneGenerator = new ToneGenerator(AudioManager.STREAM_NOTIFICATION, 100);
            toneGenerator.startTone(soundId, durationMs);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void showExceptionError(Context cont, Exception e) {
        Toast.makeText(cont, e.getMessage(), Toast.LENGTH_LONG).show();
        playSoundEx(soundError); // play default error
    }

    /**
     *
     * @param msg
     */
    public static void ToastMessage(Context cont, String msg) {
        Toast.makeText(cont, msg, Toast.LENGTH_SHORT).show();
    }

    public static void ToastMessage(Context cont, int msg) {
        Toast.makeText(cont, msg, Toast.LENGTH_SHORT).show();
    }

    public static void ToastMessage(Context cont, String msg, int time) {
        Toast.makeText(cont, msg, time).show();
    }

    public static void ToastMessageLong(Context cont, int msg) {
        Toast.makeText(cont, msg, Toast.LENGTH_LONG).show();
    }

    /**
     *
     * @param act
     * @param titleInt
     * @param messageInt
     * @param iconInt
     */
    public static void alert(Activity act, int titleInt, int messageInt, int iconInt) {
        try {
            AlertDialog.Builder builder = new AlertDialog.Builder(act);
            builder.setTitle(titleInt);
            builder.setMessage(messageInt);
            builder.setIcon(iconInt);

            builder.setNegativeButton(R.string.close, new OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            builder.create().show();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    /**
     *
     * @param act
     * @param titleInt
     * @param message
     * @param iconInt
     */
    public static void alert(Activity act, int titleInt, String message, int iconInt) {
        try {
            AlertDialog.Builder builder = new AlertDialog.Builder(act);
            builder.setTitle(titleInt);
            builder.setMessage(message);
            builder.setIcon(iconInt);

            builder.setNegativeButton(R.string.close, new OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    dialog.dismiss();
                }
            });
            builder.create().show();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static String getCurDate() {
        return formatDateLongT.format(Calendar.getInstance().getTime());
    }

    @Nullable
    public static Date getDateValue(String val) {
        Date retVal = null;
        try {
            if (val != null && !val.equals("")) {
                retVal =  formatDateLongT.parse(val);
            }
        }
        catch (ParseException e){
            e.printStackTrace();
        }
        return retVal;
    }

    public static boolean isNullOrEmpty(String s){
        boolean retVal = false;
        if (s == null || s.equals("") || s.equals("null"))
            retVal = true;
        return retVal;
    }

    public static String getHtmlGreen(String value) {
        String color = "#00FF00";
        if (value == null || value.equals(""))
            return "";
        return "<strong><font color=\"" + color+ "\">" + value + "</font></strong>";
    }

    public static boolean isEmulator() {
        return (Build.BRAND.startsWith("generic") && Build.DEVICE.startsWith("generic"))
                || Build.FINGERPRINT.startsWith("generic")
                || Build.FINGERPRINT.startsWith("unknown")
                || Build.HARDWARE.contains("goldfish")
                || Build.HARDWARE.contains("ranchu")
                || Build.MODEL.contains("google_sdk")
                || Build.MODEL.contains("Emulator")
                || Build.MODEL.contains("Android SDK built for x86")
                || Build.MANUFACTURER.contains("Genymotion")
                || Build.PRODUCT.contains("sdk_google")
                || Build.PRODUCT.contains("google_sdk")
                || Build.PRODUCT.contains("sdk")
                || Build.PRODUCT.contains("sdk_x86")
                || Build.PRODUCT.contains("sdk_gphone64_arm64")
                || Build.PRODUCT.contains("vbox86p")
                || Build.PRODUCT.contains("emulator")
                || Build.PRODUCT.contains("simulator");
    }
}
